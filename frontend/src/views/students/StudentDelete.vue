<template>
    <v-dialog max-width="700" persistent v-model="dialog">
        <template v-slot:activator="{ props: activatorProps }">
            <v-btn class="mx-3" variant="text" size="small" aria-label="Edit" icon="mdi-delete"
                v-bind="activatorProps" />
        </template>

        <template v-slot:default="{ isActive }">
            <v-card title="Editar Aluno">
                <v-form v-model="valid">
                    <v-container>
                        <v-row>
                            <v-col cols="12" md="12">
                                <h2>Deseja EXCLUIR esse aluno?</h2>
                            </v-col>
                            <v-col cols="12" md="12">
                                <v-text-field v-model="student.name" :counter="100" :rules="nameRules" label="Nome"
                                    disabled></v-text-field>
                            </v-col>
                            <v-col cols="12" md="8">
                                <v-text-field v-model="student.email" :counter="100" :rules="nameRules" label="E-mail"
                                    disabled></v-text-field>
                            </v-col>
                            <v-col cols="12" md="4">
                                <v-text-field v-model="student.name" :counter="10" :rules="nameRules" label="Data Nasc"
                                    disabled></v-text-field>
                            </v-col>
                            <v-col cols="12" md="6">
                                <v-text-field v-model="student.name" :counter="11" :rules="nameRules" label="Cpf"
                                    disabled />
                            </v-col>

                            <v-col cols="12" md="6">
                                <v-text-field v-model="student.name" :counter="10" :rules="nameRules" label="Matrícula"
                                    disabled></v-text-field>
                            </v-col>
                        </v-row>
                    </v-container>
                </v-form>
                <v-card-actions class="">
                    <v-spacer></v-spacer>
                    <v-btn text="Cancelar" @click="dialog = false"></v-btn>
                    <v-btn text="EXCLUIR" class="btn-primary" @click="onSave"></v-btn>
                </v-card-actions>
            </v-card>
        </template>
    </v-dialog>


</template>

<script setup lang="ts">
import { type Student } from "@/services/students/types";
import { useStudentStore } from '@/stores/students';
import { ref, toRefs } from "vue";

const dialog = ref(false)


const studentStore = useStudentStore();

interface Props {
    student: Student
}
const props = defineProps<Props>()
const { student } = toRefs(props);

let valid: boolean;

const nameRules: any = [

];

async function onSave() {
    var response = await studentStore.dispatchDeleteStudent(student.value.id);
    dialog.value = !response.success
}

</script>