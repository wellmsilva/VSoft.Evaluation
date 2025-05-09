<template>
  <v-dialog max-width="700" persistent v-model="dialog" class="m-5">
    <template v-slot:activator="{ props: activatorProps }">
      <v-btn class="mx-3" variant="text" size="small" aria-label="Edit" icon="mdi-eye" v-bind="activatorProps" />
    </template>

    <template v-slot:default="{ isActive }">
      <v-card title="Aulas">
        <v-container>
          <h1>Informações</h1>
          <VRow class="h-20">
            <VCol cols="12" md="12">Total: {{ totalLessons }}</VCol>
            <VCol cols="12" md="12">Concluídas: {{ student.progress }}
              <v-progress-linear color="blue-lighten-3" :model-value="student.progress" max="10" :height="9" />
            </VCol>
          </VRow>
        </v-container>
        <v-container>
          <v-data-table :headers="headers" :items="lessons" height="200" fixed-header hide-default-footer>
            <template v-slot:top>
              <v-toolbar flat>
                <v-toolbar-title>
                  <v-icon color="medium-emphasis" icon="mdi-book-multiple" size="x-small" start></v-icon>

                  Agendamento
                </v-toolbar-title>
                <ScheduleLessonView :student="student" />
              </v-toolbar>
            </template>

            <template v-slot:item.concluded="{ item }">
              <v-checkbox-btn v-model="item.concluded" :disabled="item.concluded" @change="registerConcluded(item.id)"
                :ripple="false"></v-checkbox-btn>
            </template>
          </v-data-table>
        </v-container>

        <v-card-actions class="bg-surface-light">
          <div class="d-flex ga-2 justify-end">
            <v-spacer></v-spacer>
            <v-btn text="OK" class="btn-primary" @click="dialog = false"></v-btn>
          </div>
        </v-card-actions>
      </v-card>

    </template>
  </v-dialog>

</template>

<script setup lang="ts">
import type { Lesson } from '@/services/lessons/types';
import { useLessonStore } from '@/stores/lessons';
import { onMounted, ref, toRefs } from 'vue';
import ScheduleLessonView from './ScheduleLessonView.vue';
import type { Student } from '@/services/students/types';


const lessons = ref<Lesson[]>([]);
const totalLessons = ref(0);
const concludedLessons = ref(0);

const lessonStore = useLessonStore();


onMounted(async () => {
  const { } = await lessonStore.dispatchGetLessonByStudent(student.value.id);
  lessons.value = lessonStore.lessons;
  totalLessons.value = lessonStore.totalLessons;
  concludedLessons.value = lessonStore.concludedLessons;

});


const dialog = ref(false)

interface Props {
  student: Student
}
const props = defineProps<Props>()
const { student } = toRefs(props);

const headers: any = [
  { title: 'Data', align: 'center', key: 'date' },
  { title: 'Hora', align: 'end', key: 'hour' },
  { title: 'Realizada', align: 'start', key: 'concluded' },
]

async function registerConcluded(id?: string) {
  if (id == undefined)
    return;
  await lessonStore.dispatchRegisterConcluded(id);
}

</script>
