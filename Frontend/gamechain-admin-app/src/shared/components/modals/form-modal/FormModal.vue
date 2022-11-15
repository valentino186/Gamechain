<template>
    <q-dialog persistent v-model="isVisible">
      <q-card style="max-width: 400px; width: 90%">
        <q-card-section class="row items-center">
          <span class="text-h6">{{ headerText }}</span>
        </q-card-section>

        <q-separator />

        <q-card-section class="row items-center">
            <slot></slot>
        </q-card-section>

        <q-separator />

        <q-card-actions align="right">
          <q-btn @click="handleCloseBtnClick" unelevated label="Close" color="grey-9" />
          <q-btn @click="handleSaveBtnClick" unelevated label="Save" color="primary" />
        </q-card-actions>
      </q-card>
    </q-dialog>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

export default defineComponent({
    emits: ['close', 'save'],
    props: {
      headerText: {
        type: String,
        required: true
      }
    },
    setup(props, { emit }) {
        const isVisible = ref<boolean>(true);
        const headerText = props.headerText;

        function handleCloseBtnClick() {
          emit('close');
        }

        function handleSaveBtnClick() {
          emit('save');
        }

        return {
            isVisible,
            headerText,
            handleCloseBtnClick,
            handleSaveBtnClick
        }
    }
})
</script>
