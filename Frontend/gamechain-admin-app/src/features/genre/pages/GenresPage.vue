<template>
    <q-page class="q-pa-md">
        <administration-header @create="createNew" />

        <q-table
            class="q-mt-md"
            title="Genres"
            :columns="columns"
            :rows="genres"
            :loading="loading"
            :pagination="initialPagination"
            flat
            bordered
        >
            <template #body-cell-actions="props">
                <q-td auto-width key="actions" :props="props">
                    <q-btn class="q-mr-sm" unelevated round color="deep-orange" icon="edit" size="sm" @click="handleUpdateBtnClick(props.row)" />
                    <q-btn unelevated round color="negative" icon="delete" size="sm" @click="handleDeleteBtnClick(props.row)" />
                </q-td>
            </template>
        </q-table>

        <genre-modal
            v-if="showGenreModal"
            :genre="selectedGenre"
            @save="saveGenre"
            @close="closeGenreModal">
        </genre-modal>
    </q-page>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, reactive, ref } from 'vue';
import { Genre } from 'src/shared/core/entities/genre.model';

import { useGenreService } from 'src/shared/core/services/genre.service';
import { useGenreStore } from 'src/stores/genre.store';

import AdministrationHeader from 'src/shared/components/administration-header/AdministrationHeader.vue';
import GenreModal from '../components/GenreModal.vue';

const initialGenre: Genre = {
    id: '',
    name: ''
}

export default defineComponent({
    components: { AdministrationHeader, GenreModal },
    setup() {
        const selectedGenre = reactive<Genre>({
            id: '',
            name: ''
        });

        const showGenreModal = ref<boolean>(false);

        const genreService = useGenreService();
        const genreStore = useGenreStore();

        const genres = computed(() => genreStore.state.genres);
        const loading = computed(() => genreStore.state.loading);

        const columns = [
            { name: 'name', align: 'left', label: 'Name', field: 'name', sortable: true },
            { name: 'actions', align: 'center', label: 'Actions' }
        ];

        const initialPagination = {
            sortBy: 'name'
        }

        onMounted(() => {
            genreService.getGenres();
            setSelectedGenre(initialGenre);
        })

        function createNew() {
            showGenreModal.value = true;
        }

        function saveGenre(genre: Genre) {
            if (selectedGenre.id)
                updateGenre(genre);
            else
                createGenre(genre);

            closeGenreModal();
        }

        function createGenre(genre: Genre) {
            genreService.createGenre(genre);
        }

        function updateGenre(genre: Genre) {
            genreService.updateGenre(genre);
        }

        function handleUpdateBtnClick(genre: Genre) {
            setSelectedGenre(genre);
            showGenreModal.value = true;
        }

        function closeGenreModal() {
            showGenreModal.value = false;
            setSelectedGenre(initialGenre);
        }

        function setSelectedGenre(genre: Genre) {
            Object.assign(selectedGenre, genre);
        }

        return {
            selectedGenre,
            showGenreModal,
            genres,
            loading,
            columns,
            initialPagination,
            createNew,
            saveGenre,
            handleUpdateBtnClick,
            closeGenreModal
        }
    }
})
</script>