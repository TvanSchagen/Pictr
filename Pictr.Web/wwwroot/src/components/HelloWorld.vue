<template>
  <h1>{{ msg }}</h1>
  <h2>[API status: {{ status ?? 'loading..' }}]</h2>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";

defineProps<{ msg: string }>();

const status = ref<string>();

onMounted(async () => {
  try {
    const res = await fetch('/api/status');
    const text = await res.text();
    status.value = text;
  } catch (err) {
    status.value = 'Unknown error';
  }
});
</script>

<style scoped>
</style>
