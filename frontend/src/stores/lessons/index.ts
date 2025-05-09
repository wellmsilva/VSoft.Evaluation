import { API } from "@/services";
import type { Lesson, CreateNewLessonResquest } from "@/services/lessons/types";
import type { APIResponse } from "@/services/types";
import type { AxiosError } from "axios";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useLessonStore = defineStore("lessonStore", () => {

  const lessons = ref<Lesson[]>([]);
  const totalLessons = computed(() => lessons.value.length ?? 0)
  const concludedLessons = computed(() => lessons.value.filter(x => x.concluded == true).length)

  function init(data: Lesson[]) {
    lessons.value = data;
  }

  function addNewLesson(student: Lesson) {
    lessons.value.push(student);
  }

  async function dispatchGetLessonByStudent(studentId: string): Promise<APIResponse<null>> {
    try {
      const { status, data } = await API.lesson.getLessonByStudent(studentId);
      if (status === 200) {
        init(data.items);
        return {
          success: true,
          items: null,
        };
      }
    } catch (error) {
      const _error = error as AxiosError<string>;
      return {
        success: false,
        status: _error.response?.status,
        items: null,
      };
    }
    return {
      success: false,
      items: null,
      status: 400,
    };
  }

  async function dispatchNewScheduleLesson(request: CreateNewLessonResquest): Promise<APIResponse<null>> {
    try {
      const { status, data } = await API.lesson.createNewLesson(request);
      if (status === 201) {
        addNewLesson(data)
        return {
          success: true,
          items: null,
        };
      }
    } catch (error) {
      const _error = error as AxiosError<string>;
      return {
        success: false,
        status: _error.response?.status,
        items: null,
      };
    }
    return {
      success: false,
      items: null,
      status: 400,
    };
  }

  async function dispatchRegisterConcluded(id: string, concluded: boolean = true): Promise<APIResponse<null>> {
    try {
      const { status } = await API.lesson.registerConcludedLesson(id);
      if (status === 200) {
        lessons.value.forEach((element, index) => {
          if (element.id === id) {
            lessons.value[index].concluded = concluded;
          }
        });

        return {
          success: true,
          items: null,
        };
      }
    } catch (error) {
      const _error = error as AxiosError<string>;
      return {
        success: false,
        status: _error.response?.status,
        items: null,
      };
    }
    return {
      success: false,
      items: null,
      status: 400,
    };
  }


  return {
    lessons,
    totalLessons,
    concludedLessons,
    init,
    dispatchGetLessonByStudent,
    dispatchNewScheduleLesson,
    dispatchRegisterConcluded
  };
})


