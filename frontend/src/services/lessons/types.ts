export type Lesson = {
  id: string,
  date: string,
  hour: string,
  concluded: boolean
}

export type NewScheduleLesson = {
  studentId: string;
  date: string;
  hour: string
}

export type CreateNewLessonResquest = {
  studentId: string;
  date: string;
  hour: string
}
