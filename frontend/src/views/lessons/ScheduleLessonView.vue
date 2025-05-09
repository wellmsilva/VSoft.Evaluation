<template>
  <v-dialog max-width="300" persistent v-model="dialog" class="m-5">
    <template v-slot:activator="{ props: activatorProps }">
      <v-btn class="me-2" prepend-icon="mdi-plus" rounded="lg" text="Novo" @click="" v-bind="activatorProps" />
    </template>
    <template v-slot:default="{ isActive }">
      <v-card title="Novo Agendamento" class="bg-surface-light">
        <v-form v-model="valid">
          <v-container>
            <v-row>
              <v-col cols="12" md="12">
                <v-text-field v-model="scheduleLesson.date" :counter="100" label="Data" type="date"
                  required></v-text-field>
              </v-col>
              <v-col cols="12" md="12">
                <v-text-field v-model="scheduleLesson.hour" :counter="100" label="Hora" type="time"
                  required></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-form>
        <v-card-actions class="bg-surface-light">
          <div class="d-flex ga-2 justify-end">
            <v-spacer></v-spacer>
            <v-btn text="Cancelar" class="btn-primary" @click="onCancel" />
            <v-btn text="Salvar" class="btn-primary" @click="onSave" />
          </div>
        </v-card-actions>

      </v-card>
    </template>
  </v-dialog>
</template>

<script setup lang="ts">
import type { NewScheduleLesson } from '@/services/lessons/types';
import type { Student } from '@/services/students/types';
import { useLessonStore } from '@/stores/lessons';
import { ref, toRefs } from 'vue';

interface Props {
  student: Student
}
const props = defineProps<Props>()
const { student } = toRefs(props);

const dialog = ref(false)
const valid = ref(false)


const lessonStore = useLessonStore();

const scheduleLesson = ref<NewScheduleLesson>({} as NewScheduleLesson);

async function onSave() {
  scheduleLesson.value.studentId = student.value.id;
  const response = await lessonStore.dispatchNewScheduleLesson(scheduleLesson.value);
  dialog.value = !response.success;
}

async function onCancel() {
  scheduleLesson.value = {} as NewScheduleLesson;
  dialog.value = false;
}
</script>
