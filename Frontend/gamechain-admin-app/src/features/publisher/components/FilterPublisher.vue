<template>
    <base-filter
        @reset="handleResetBtnClick"
        @search="handleSearchBtnClick"
    >
        <q-input
            v-model="filterValue.name"
            dense
            outlined 
            label="Name" />
    </base-filter>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import BaseFilter from 'src/shared/components/BaseFilter.vue'

export default defineComponent({
    components: { BaseFilter },
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