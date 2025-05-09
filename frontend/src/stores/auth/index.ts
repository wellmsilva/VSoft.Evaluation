import router from "@/router";
import { API } from "@/services";
import type { LoginUserRequest, User } from "@/services/users/types";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useAuthStore = defineStore("authStore ", () => {
  const token = ref(localStorage.getItem('token'));
  const user = ref<User>(JSON.parse(localStorage.getItem("user")!));

  const logged = computed(() => !!token)

  function setToken(value: string) {
    token.value = value;
    localStorage.setItem('token', token.value);
    token.value = value;
  }

  function setUser(value: User) {
    user.value = value;
    localStorage.setItem('user', JSON.stringify(user.value));
  }

  function logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    token.value = '';
    router.push('login')
  }

  async function dispatchLogin(request: LoginUserRequest): Promise<boolean> {
    const { status, data } = await API.user.login(request);
    if (status === 200) {
      setToken(data.token);
      setUser({ name: data.name, role: data.role });
      return true;
    }

    logout();
    return false;
  };

  return {
    token,
    user,
    logged,
    dispatchLogin,
    logout
  }
})




