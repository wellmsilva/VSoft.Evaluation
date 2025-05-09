<template>
  <VContainer>
    <v-card>
      <v-form v-model="valid">
        <v-container>
          <v-row>
            <v-col cols="12" md="12">
              <v-text-field type="number" v-model="userName.value.value" class="me-10"
                :error-messages="userName.errorMessage.value" label="cpf"></v-text-field>
            </v-col>
            <v-col cols="12" md="12">
              <v-text-field v-model="password.value.value" :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                :type="showPassword ? 'text' : 'password'" class="mb-4" label="Password" counter
                :error-messages="password.errorMessage.value"
                @click:append="showPassword = !showPassword"></v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-form>
      <v-card-actions class="bg-surface-light">
        <div class="d-flex ga-2 justify-end">
          <v-spacer></v-spacer>
          <v-btn text="Entrar" class="btn-primary" @click="onSubmit"></v-btn>
        </div>
      </v-card-actions>
    </v-card>
  </VContainer>
</template>


<script setup lang="ts">
import router from '@/router';
import type { LoginUserRequest } from '@/services/users/types';
import { useAuthStore } from '@/stores/auth';
import { useField, useForm } from 'vee-validate'
import { ref } from 'vue';

const { handleSubmit } = useForm({
  validationSchema: {
    userName(value: string) {
      if (value?.length == 11) return true
      return 'Must be a valid cpf.'
    },
    password(value: string) {
      if (value?.length >= 6) return true
      return 'Password length needs to be at least 6.'
    }
  },
})
// Fields
const userName = useField('userName')
const password = useField('password')
const valid = ref(false)
const showPassword = ref(false)

const authStore = useAuthStore();




const onSubmit = handleSubmit(async values => {
  const userRequest = {
    userName: values.userName,
    password: values.password
  } as LoginUserRequest
  const data = await authStore.dispatchLogin(userRequest);
})
</script>
