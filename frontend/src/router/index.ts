import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from '@/stores/auth';



const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      redirect: to => {
        const authStore = useAuthStore();

        if (authStore.user?.role == 'CFC') {
          return '/students';
        } else {
          return '/student';
        }
      }
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/auth/LoginView.vue'),
    },
    {
      path: '/student',
      name: 'student',
      component: () => import('../views/student/StudentDetailsView.vue'),
      meta: { requiresAuth: true, role: 'Student' },
    },
    {
      path: '/students',
      name: 'students',
      component: () => import('../views/students/StudentView.vue'),
      meta: { requiresAuth: true, role: 'CFC' },
    },
  ],
})

router.beforeEach((to, from, next) => {
  const authStore = useAuthStore();
  const isAuthenticated = !!authStore.token;

  if (to.meta.requiresAuth && !isAuthenticated) {
    next({ name: 'login' });
    return
  }

  next();

});

export default router
