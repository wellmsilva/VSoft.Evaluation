import http from "../api";
import type { APIResponse } from "../types";
import type { CreateNewLessonResquest, Lesson } from "./types";

async function registerConcludedLesson(id: string) {
  return await http.put<APIResponse<boolean>>(`lesson/conclude`, { id: id });
}

async function getLessonByStudent(id: string) {
  return await http.get<APIResponse<Lesson[]>>(`lesson/student/${id}`);
}

async function createNewLesson(request: CreateNewLessonResquest) {
  return await http.post<Lesson>(`lesson/schedule`, request);
}

export default {
  registerConcludedLesson,
  getLessonByStudent,
  createNewLesson
};
