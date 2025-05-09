export type APIResponse<T> = {
  success: boolean
  items: T;
  status?: number;
}