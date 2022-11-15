<template>
    <q-dialog v-model="isVisible" persistent>
        <q-card style="max-width: 300px; width: 90%">
            <q-card-section class="column items-center">
                <q-icon class="text-h3 q-mb-md" color="grey-9" name="help_outline" />
                <span class="text-justify">{{ displayMessage }}</span>
            </q-card-section>

            <q-card-actions align="right">
                <q-btn @click="handleCancelBtnClick" unelevated label="Cancel" color="grey-9" v-close-popup />
                <q-btn @click="handleOkBtnClick" unelevated label="OK" color="primary" v-close-popup />
            </q-card-actions>
        </q-card>
    </q-dialog>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";

export default defineComponent({
    emits: ['cancel', 'ok'],
    props: {
        displayMessage: {
            type: String,
            required: true
        }
    },
    setup(props, { emit }) {
        const isVisible = ref<boolean>(true);

        const displayMessage = props.displayMessage;

        function handleCancelBtnClick() {
            emit('cancel');
        }

        function handleOkBtnClick() {
            emit('ok');
        }

        return {
            isVisible,
            displayMessage,
            handleCancelBtnClick,
            handleOkBtnClick
        }
    }
})
</script>