<template>
    <q-card flat bordered class="my-card">
        <q-card-section>
            <q-btn @click="handleCreateNewBtnClick" unelevated color="primary" size="md" label="Create New" />
        </q-card-section>
    </q-card>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
    emits: ["create"],
    setup(_, { emit }) {
        function handleCreateNewBtnClick() {
            emit("create");
        }

        return {
            handleCreateNewBtnClick
        }
    }
})
</script>