import { createStore } from 'vuex'

export default createStore({
  state: {
    lat: null,
    long: null,
    areas: [],
    selectedArea: null,
    climbs: [],
    selectedClimb: null,
    notes: null,
    completed: false
  },
  mutations: {
    SET_LAT(state, lat) {
      state.lat = lat;
    },
    SET_LONG(state, long) {
      state.long = long;
    },
    SET_AREAS(state, areas) {
      state.areas = areas;
    },
    SET_SELECTED_AREA(state, area) {
      state.selectedArea = area;
    },
    SET_CLIMBS(state, climbs) {
      state.climbs = climbs;
    },
    SET_SELECTED_CLIMB(state, climb) {
      state.selectedClimb = climb;
      console.log(state.selectedClimb);
    },
    SET_NOTES(state, notes) {
      state.notes = notes;
    },
    SET_COMPLETED(state, completed) {
      state.completed = completed;
    }
  },
  actions: {
  },
  modules: {
  }
})
