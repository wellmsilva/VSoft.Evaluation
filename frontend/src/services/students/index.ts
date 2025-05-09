import http from "../api";
import type { APIResponse } from "../types";
import type { CreateStudentRequest, GetStudentsRequest, Student } from "./types";

async function getStudents(request: GetStudentsRequest) {
  return await http.get<APIResponse<Student[]>>("student", {
    params: request
  });
}

async function getStudentByCpf(value: string) {
  return await http.get<Student>("student/details", {
    params: { cpf: value }
  });
}

async function createStudent(request: CreateStudentRequest) {
  return await http.post<Student>("student", request);
}

async function deleteStudent(id: string) {
  return await http.delete<APIResponse<boolean>>(`student/${id}`);
}

export default {
  getStudents,
  createStudent,
  getStudentByCpf,
  deleteStudent,
};
