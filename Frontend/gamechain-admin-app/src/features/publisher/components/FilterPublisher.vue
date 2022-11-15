<template>
    <q-card flat bordered class="my-card">
        <q-card-section class="row justify-between items-center">
            <q-input
                v-model="filterValue.name"
                outlined 
                label="Name" />

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
    emits: ['search'],
    setup(_, { emit }) {
        const filterValue = reactive({
            name: ''
        })

        function handleResetBtnClick() {
            filterValue.name = '';
            emit('search', filterValue);
        }

        function handleSearchBtnClick() {
            emit('search', filterValue);
        }

        return {
            filterValue,
            handleResetBtnClick,
            handleSearchBtnClick
        }
    }
})
</script>