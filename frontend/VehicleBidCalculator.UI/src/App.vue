<script setup lang="ts">
import { RouterView } from 'vue-router'
</script>

<template>
  <div class="app-container">
    <header class="main-header">
      <div class="header-content">
        <i class="pi pi-car header-icon"></i>
        <h1>Vehicle Bid Calculator</h1>
        <p class="header-subtitle">Calculate total auction costs with fees</p>
      </div>
    </header>
    <main class="main-content">
      <RouterView />
    </main>
  </div>
</template>

<style scoped>
.app-container {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

.main-header {
  background: rgba(255, 255, 255, 0.96);
  backdrop-filter: blur(10px);
  padding: 2rem 1rem;
  text-align: center;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.15);
  border-bottom: 3px solid #667eea;
}

.header-content {
  max-width: 1200px;
  margin: 0 auto;
}

.header-icon {
  font-size: 3.5rem;
  color: #667eea;
  margin-bottom: 1rem;
}

.main-header h1 {
  margin: 0 0 0.5rem 0;
  font-size: 2.8rem;
  color: #2c3e50;
  font-weight: 700;
  letter-spacing: -0.5px;
}

.header-subtitle {
  margin: 0;
  font-size: 1.2rem;
  color: #6c757d;
  font-weight: 400;
}

.main-content {
  flex: 1;
  padding: 2.5rem 1rem;
  display: flex;
  justify-content: center;
  align-items: flex-start;
}
</style>
