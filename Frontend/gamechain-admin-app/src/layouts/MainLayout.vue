<template>
  <q-layout view="hHh lpR fFf">
    <q-header bordered class="bg-grey-9 text-white">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="toggleLeftDrawer" />

        <q-toolbar-title> Gamechain Admin </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer
      class="bg-grey-10"
      show-if-above
      v-model="leftDrawerOpen"
      side="left"
      bordered
    >
      <q-item to="/platforms" class="text-white" clickable>
        <q-item-section avatar>
          <q-icon name="sports_esports" />
        </q-item-section>

        <q-item-section>Platforms</q-item-section>
      </q-item>

      <q-item to="/publishers" class="text-white" clickable >
        <q-item-section avatar>
          <q-icon name="groups_2" />
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
