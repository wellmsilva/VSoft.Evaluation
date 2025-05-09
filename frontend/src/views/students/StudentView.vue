<template>
  <Header title="ARÉA DO CFC"></Header>

  <v-container>
    <v-row>
      <v-col cols="12" md="4">
        <v-text-field v-model="queryString" label="CPF/Matrícula" required></v-text-field>
      </v-col>
    </v-row>

    <v-table>
      <thead>
        <tr class="">
          <th class="text-left text-caption">
            Name
          </th>
          <th class="text-left text-caption">
            Cpf
          </th>
          <th class="text-left text-caption">
            email
          </th>
          <th class="text-left text-caption">
            Data Nasc.
          </th>
          <th class="text-left text-caption">
            Matrícula
          </th>
          <th class="text-left text-caption">
            Progresso
          </th>
          <th class="text-left text-caption">
            Prática
          </th>
          <th class="text-left text-caption">
            <StudentCreate />
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="student in students" :key="student.name">
          <td>{{ student.name }}</td>
          <td>{{ student.cpf }}</td>
          <td>{{ student.email }}</td>
          <td>{{ student.dateBirth }}</td>
          <td>{{ student.registration }}</td>
          <td>{{ student.progress }} concluida(s)
            <v-progress-linear color="blue-lighten-3" :model-value="student.progress" max="10" :height="9" />
          </td>
          <td> <v-checkbox-btn v-model="student.canLessonsPractical" :disabled="true" /></td>
          <td>
            <StudentEdit :student="student" />
            <StudentDelete :student="student" />
            <LessonsView :student="student" />
          </td>
        </tr>
      </tbody>
    </v-table>
  </v-container>

</template>

<script setup lang="ts">
import StudentCreate from "./StudentCreate.vue"
import type { Student } from '@/services/students/types';
import { useStudentStore } from '@/stores/students';
import { onMounted, ref } from 'vue';
import StudentEdit from "./StudentEdit.vue";
import StudentDelete from "./StudentDelete.vue";
import LessonsView from "../lessons/LessonsView.vue";
import Header from '@/components/Header.vue';


const queryString = ref("");

const students = ref<Student[]>([]);

const studentStore = useStudentStore();


onMounted(async () => {
  const { success, status } = await studentStore.dispatchGetStudents(queryString.value);
  students.value = studentStore.students;

});


</script>
