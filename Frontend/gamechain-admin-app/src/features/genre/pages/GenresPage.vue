<template>
    <q-page class="q-pa-md">
        <administration-header @create="createNew" />

        <filter-genre
            @search="filterGenres"
            class="q-mt-md">
        </filter-genre>

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

        <confirmation-modal
            v-if="showConfirmationModal"
            :displayMessage="`Are you sure you want to delete '${selectedGenre.name}'?`"
            @ok="deleteGenre"
            @cancel="closeConfirmationModal">
        </confirmation-modal>
    </q-page>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, reactive, ref } from 'vue';
import { Genre } from 'src/shared/core/entities/genre.model';
import { GenreFilterForm } from 'src/shared/infrastructure/models/filters/genre-filter-form.model';

import { useGenreService } from 'src/shared/core/services/genre.service';
import { useGenreStore } from 'src/stores/genre.store';

import AdministrationHeader from 'src/shared/components/administration-header/AdministrationHeader.vue';
import ConfirmationModal from 'src/shared/components/modals/confirmation-modal/ConfirmationModal.vue';
import GenreModal from '../components/GenreModal.vue';
import FilterGenre from '../components/FilterGenre.vue';

const initialGenre: Genre = {
    id: '',
    name: ''
}

export default defineComponent({
    components: { AdministrationHeader, ConfirmationModal, GenreModal, FilterGenre },
    setup() {
        const selectedGenre = reactive<Genre>({
            id: '',
            name: ''
        });

        const showGenreModal = ref<boolean>(false);
        const showConfirmationModal = ref<boolean>(false);

        const genreService = useGenreService();
        const genreStore = useGenreStore();

        const genres = computed(() => genreStore.getGenres());
        const loading = computed(() => genreStore.state.loading);

        const columns = [
            { name: 'name', align: 'left', label: 'Name', field: 'name', sortable: true },
            { name: 'actions', align: 'center', label: 'Actions' }
        ];

        const initialPagination = {
            sortBy: 'name'
        }

        onMounted(() => {
            setSelectedGenre(initialGenre);
            genreService.getGenres();
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

        function filterGenres(genreFilterForm: GenreFilterForm) {
            genreStore.setFilters(genreFilterForm);
        }

        function handleUpdateBtnClick(genre: Genre) {
            setSelectedGenre(genre);
            showGenreModal.value = true;
        }

        function handleDeleteBtnClick(genre: Genre) {
            setSelectedGenre(genre);
            showConfirmationModal.value = true;
        }

        function closeGenreModal() {
            showGenreModal.value = false;
            setSelectedGenre(initialGenre);
        }

        function deleteGenre() {
            genreService.deleteGenre(selectedGenre.id);
            closeConfirmationModal();
        }

        function closeConfirmationModal() {
            showConfirmationModal.value = false;
            setSelectedGenre(initialGenre);
        }

        function setSelectedGenre(genre: Genre) {
            Object.assign(selectedGenre, genre);
        }

        return {
            selectedGenre,
            showGenreModal,
            showConfirmationModal,
            genres,
            loading,
            columns,
            initialPagination,
            createNew,
            saveGenre,
            filterGenres,
            handleUpdateBtnClick,
            handleDeleteBtnClick,
            closeGenreModal,
            deleteGenre,
            closeConfirmationModal
        }
    }
})
</script>