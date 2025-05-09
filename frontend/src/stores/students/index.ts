import { API } from "@/services";
import type { CreateStudentRequest, GetStudentsRequest, Student } from "@/services/students/types";
import type { APIResponse } from "@/services/types";
import type { AxiosError } from "axios";
import { defineStore } from "pinia";
import { ref } from 'vue';


export const useStudentStore = defineStore("studentStore", () => {

  const students = ref<Student[]>([]);
  const selected = ref<Student>();

  function initStudents(data: Student[]) {
    students.value = data;
  }

  function addNewStudent(student: Student) {
    students.value.push(student);
  }

  function setSelected(value: Student) {
    selected.value = value;
  }

  function removeStudent(id: string) {
    const idx = students.value.findIndex(s => s.id === id);
    if (idx === -1) return;
    students.value.splice(idx, 1);
  }

  async function dispatchGetStudentByCpf(value: string) {
    try {
      const { data } = await API.student.getStudentByCpf(value);
      if (data) {
        setSelected(data);
        return {
          success: true,
          data: data,
        };
      }
    } catch (error) {
      const _error = error as AxiosError<string>;
      return {
        success: false,
        status: _error.response?.status,
        data: null,
      };
    }
    return {
      success: false,
      items: null,
      status: 400,
    };
  }

  async function dispatchGetStudents(query: string): Promise<APIResponse<null>> {
    try {
      const { status, data } = await API.student.getStudents({ query: query } as GetStudentsRequest);
      if (status === 200) {
        initStudents(data.items);
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

  async function dispatchCreateStudent(
    request: CreateStudentRequest
  ): Promise<APIResponse<null>> {
    try {
      const { status, data } = await API.student.createStudent(request);
      if (status === 201) {
        addNewStudent(data);
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

  async function dispatchDeleteStudent(id: string): Promise<APIResponse<null>> {
    try {
      const { status } = await API.student.deleteStudent(id);
      if (status === 200) {
        removeStudent(id);
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
    students,
    selected,
    initStudents,
    addNewStudent,
    removeStudent,
    dispatchGetStudents,
    dispatchCreateStudent,
    dispatchDeleteStudent,
    dispatchGetStudentByCpf
  };
});
