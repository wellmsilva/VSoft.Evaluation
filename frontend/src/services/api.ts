
import axios from 'axios';

const token = localStorage.getItem('token')!;
const authorization = token ? `Bearer ${token}` : null;

const instance = axios.create({
  baseURL: import.meta.env.VITE_BASE_URL,
  headers: {
    "Access-Control-Allow-Origin": "*",
    "Content-type": "Application/json",
    "Authorization": authorization
  }
});
export default instance
