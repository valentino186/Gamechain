<template>
  <q-layout view="hHh lpR fFf">
    <q-header bordered class="vf-bg-indigo-6 text-white">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="toggleLeftDrawer" />

        <q-toolbar-title> Gamechain Admin </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer
      class="vf-bg-indigo-10"
      show-if-above
      v-model="leftDrawerOpen"
      side="left"
      bordered
    >
      <q-item class="text-white" clickable>
        <q-item-section avatar>
          <q-icon name="inbox" />
        </q-item-section>

        <q-item-section>Publishers</q-item-section>
      </q-item>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { ref } from "vue";

export default {
  setup() {
    const leftDrawerOpen = ref(false);

    return {
      leftDrawerOpen,
      toggleLeftDrawer() {
        leftDrawerOpen.value = !leftDrawerOpen.value;
      },
    };
  },
};
</script>
