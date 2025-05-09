<template>
  <Header title="ARÉA DO ALUNO"></Header>
  <v-container>
     <VRow class="h-20" >
      <VCol cols="12" md="6" class="text-h6">Total: {{ totalLessons }}</VCol>
      <VCol cols="12" md="6"class="text-h6">Apto Prática: {{ student.canLessonsPractical ? 'SIM' : 'NÃO' }}</VCol>
      <VCol cols="12" md="12"class="text-h6">Concluídas: {{ student.progress }}
        <v-progress-linear color="blue-lighten-3" :model-value="student.progress" max="10" :height="9" />
      </VCol>
    </VRow>
  </v-container>
  <v-container>
    <v-data-table :headers="headers" :items="lessons" fixed-header hide-default-footer>
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>
            <v-icon color="medium-emphasis" icon="mdi-book-multiple" size="x-small" start></v-icon>

            Agendamento
          </v-toolbar-title>
        </v-toolbar>
      </template>

      <template v-slot:item.concluded="{ item }">
        <v-checkbox-btn v-model="item.concluded" :disabled="true" :ripple="false"/>
      </template>
    </v-data-table>
  </v-container>

</template>


<script setup lang="ts">
import type { Lesson } from '@/services/lessons/types';
import { useLessonStore } from '@/stores/lessons';
import { useStudentStore } from '@/stores/students';
import { onMounted, ref, toRefs } from 'vue';
import type { Student } from '@/services/students/types';
import Header from '@/components/Header.vue';


const lessons = ref<Lesson[]>([]);
const student = ref<Student>({} as Student);
const totalLessons = ref(0);
const concludedLessons = ref(0);

const lessonStore = useLessonStore();
const studentStore = useStudentStore();



onMounted(async () => {
  const res = await studentStore.dispatchGetStudentByCpf("12313131231");
  if (!res.success)
    return;

  student.value = res.data!;
  const { } = await lessonStore.dispatchGetLessonByStudent(student.value.id);
  lessons.value = lessonStore.lessons;
  totalLessons.value = lessonStore.totalLessons;
  concludedLessons.value = lessonStore.concludedLessons;

});


const dialog = ref(false)

const headers: any = [
  { title: 'Data', align: 'center', key: 'date' },
  { title: 'Hora', align: 'end', key: 'hour' },
  { title: 'Realizada', align: 'start', key: 'concluded' },
]

</script>