<template>
    <v-dialog max-width="700" persistent v-model="dialog">
        <template v-slot:activator="{ props: activatorProps }">
            <v-btn class="mx-3" variant="text" size="small" aria-label="Edit" icon="mdi-pencil"
                v-bind="activatorProps" />
        </template>

        <template v-slot:default="{ isActive }">
            <v-card title="Editar Aluno">
                <v-form v-model="valid">
                    <v-container>
                        <v-row>
                            <v-col cols="12" md="12">
                                <v-text-field v-model="student.name" :counter="100" :rules="nameRules" label="Nome"
                                    disabled required></v-text-field>
                            </v-col>
                            <v-col cols="12" md="8">
                                <v-text-field v-model="student.email" :counter="100" :rules="nameRules" label="E-mail"
                                    required></v-text-field>
                            </v-col>
                            <v-col cols="12" md="4">
                                <v-text-field v-model="student.dateBirth" :counter="10" :rules="nameRules"
                                    label="Data Nasc" required></v-text-field>
                            </v-col>
                            <v-col cols="12" md="6">
                                <v-text-field v-model="student.cpf" :counter="11" :rules="nameRules" label="Cpf"
                                    disabled required />
                            </v-col>

                            <v-col cols="12" md="6">
                                <v-text-field v-model="student.registration" :counter="10" :rules="nameRules" disabled
                                    label="Matrícula" required></v-text-field>
                            </v-col>
                        </v-row>
                    </v-container>
                </v-form>
                <v-card-actions class="">
                    <v-spacer></v-spacer>
                    <v-btn text="Cancelar" @click="dialog = false"></v-btn>
                    <v-btn text="Salvar" class="btn-primary" @click="onSave"></v-btn>
                </v-card-actions>
            </v-card>
        </template>
    </v-dialog>
</template>

<script setup lang="ts">
import { type CreateStudentRequest } from "@/services/students/types";
import { ref, toRefs } from "vue";

const dialog = ref(false)

interface Props {
    student: CreateStudentRequest
}
const props = defineProps<Props>()
const { student } = toRefs(props);


let valid: boolean;

const nameRules: any = [];

function onSave() {
    dialog.value = false


}

</script>