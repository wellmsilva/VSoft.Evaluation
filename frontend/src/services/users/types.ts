export type User = {
  name: string;
  role: string;
}


export type LoginUserRequest = {
  userName: string;
  password: string;
}

export type LoginUserResponse = {
  token: string,
  name: string,
  role: string
}
