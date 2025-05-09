export type Student = {
  id: string;
  email: string;
  name: string;
  cpf: string;
  dateBirth: Date;
  progress: number;
  registration: string;
  canLessonsPractical: boolean
}

export interface CreateStudentRequest {
  email: string;
  name: string;
  cpf: string;
  dateBirth: Date;
  registration: string;
}

export type GetStudentsRequest = {
  query: string
}
