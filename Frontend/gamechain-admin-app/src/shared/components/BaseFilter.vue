<template>
    <q-card flat bordered class="my-card">
        <q-card-section class="row justify-between items-center">
            <slot></slot>
            <div>
                <q-btn
                    class="q-mr-sm" 
                    @click="handleResetBtnClick" 
                    round 
                    unelevated
                    icon="undo"
                    color="grey-9" 
                    size="md" />

                <q-btn
                    @click="handleSearchBtnClick" 
                    round 
                    unelevated
                    icon="search"
                    color="primary" 
                    size="md" />
            </div>
        </q-card-section>
    </q-card>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';

export default defineComponent({
    emits: ['search', 'reset'],
    setup(_, { emit }) {

        function handleResetBtnClick() {
            emit('reset');
        }

        function handleSearchBtnClick() {
            emit('search');
        }

        return {
            handleResetBtnClick,
            handleSearchBtnClick
        }
    }
})
</script>