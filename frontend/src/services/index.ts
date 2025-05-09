import studentsController from "./students";
import lessonsController from "./lessons";
import usersController from "./users";

export const API = {
  student: studentsController,
  lesson: lessonsController,
  user: usersController,
};
