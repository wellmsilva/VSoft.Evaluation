import http from "../api";
import type { LoginUserRequest, LoginUserResponse } from "./types";

async function login(request: LoginUserRequest) {
  return await http.post<LoginUserResponse>("user/login", request);
}

export default {
  login
}
