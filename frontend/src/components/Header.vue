<template>
    <header class="bg-white shadow-md h-24 flex justify-between items-stretch">
        <h1 class="inline-flex items-center px-5 h-full text-h4">{{ title }}</h1>
        <div class="flex items-center gap-1  h-full pr-5">
            <v-btn class="primary" variant="flat" @click="onLogout" :hidden="!logged">Sair</v-btn>
        </div>
    </header>
</template>

<script setup lang="ts">
import { useAuthStore } from '@/stores/auth';
import { toRefs } from 'vue';




defineProps({
    title: { type: String, required: false, default: '' },
});


const userStore = useAuthStore();

const logged = userStore.logged;

function onLogout()  {
    userStore.logout();

}
</script>