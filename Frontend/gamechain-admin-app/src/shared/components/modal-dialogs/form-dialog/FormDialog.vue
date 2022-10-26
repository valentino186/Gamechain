<template>
    <q-dialog persistent v-model="isVisible">
      <q-card style="max-width: 400px; width: 90%">
        <q-card-section class="row items-center">
          <span class="text-h6">Publisher</span>
        </q-card-section>

        <q-separator />

        <q-card-section class="row items-center">
            <slot></slot>
        </q-card-section>

        <q-separator />

        <q-card-actions align="right">
          <q-btn unelevated label="Close" color="grey-9" v-close-popup />
          <q-btn @click="save" unelevated label="Save" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

export default defineComponent({
    emits: ['save'],
    setup(_, { emit }) {
        const isVisible = ref<boolean>(true);

        function handleSaveBtnClick() {
          emit('save');
        }

        return {
            isVisible,
            handleSaveBtnClick
        }
    }
})
</script>
