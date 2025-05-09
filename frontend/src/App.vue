<template>
  <div class="bg-gray-100 h-full">
    <!-- <header class="bg-white shadow-md h-24 flex justify-between items-stretch">
      <RouterLink to="/" class="inline-flex items-center px-5 h-full">Home</RouterLink>
      <div class="flex items-center gap-1  h-full pr-5">
        <RouterLink to="/students" class="inline-flex items-center px-2 h-full transition-colors hover:bg-orange-200">
          Alunos
        </RouterLink>
        <RouterLink to="/login" class="inline-flex items-center px-2 h-full transition-colors hover:bg-orange-200">Aulas
        </RouterLink>
      </div>
    </header> -->
    <main class="p-5">
      <RouterView />
    </main>
  </div>



  <header>
    <div class="wrapper">
      <nav>

      </nav>
    </div>
  </header>


</template>

<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>
