<template>
  <v-dialog max-width="500" persistent v-model="dialog">
    <template v-slot:activator="{ props: activatorProps }">
      <v-btn class="mx-3" variant="text" size="small" aria-label="Edit" icon="mdi-account-plus"
        v-bind="activatorProps" />
    </template>

    <template v-slot:default="{ }">
      <v-card title="Cadastrar Aluno">
        <v-form v-model="valid">
          <v-container>
            <v-row>
              <v-col cols="12" md="12">
                <v-text-field v-model="student.name" :counter="100" :rules="nameRules" label="Nome"
                  required></v-text-field>
              </v-col>
              <v-col cols="12" md="7">
                <v-text-field v-model="student.email" :counter="100" :rules="nameRules" label="E-mail"
                  required></v-text-field>
              </v-col>
              <v-col cols="12" md="5">
                <v-text-field v-model="student.dateBirth" :counter="10" :rules="nameRules" type="date" label="Data Nasc"
                  required></v-text-field>
              </v-col>
              <v-col cols="12" md="6">
                <v-text-field v-model="student.cpf" :counter="11" :rules="nameRules" label="Cpf" required
                  mask="###.###.###-##" />
              </v-col>

              <v-col cols="12" md="6">
                <v-text-field v-model="student.registration" :counter="10" :rules="nameRules" label="Matrícula"
                  required></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-form>
        <v-card-actions class="bg-surface-light">
          <v-spacer></v-spacer>
          <v-btn text="Cancelar" @click="dialog = false"></v-btn>
          <v-btn text="Salvar" class="btn-primary" @click="onSave"></v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>

<script setup lang="ts">
import type { CreateStudentRequest } from '@/services/students/types';
import { useStudentStore } from '@/stores/students';
import { ref } from "vue";

let valid: boolean;
const dialog = ref(false)

const student = ref<CreateStudentRequest>({} as CreateStudentRequest);
const nameRules: any = [];

const studentStore = useStudentStore();


function onSave() {
  studentStore.dispatchCreateStudent(student.value)
    .then(res => {
      dialog.value = !res.success
    }).catch(err => {
      console.log(err);
    });

}
</script>
