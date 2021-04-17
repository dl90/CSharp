<template>
  <div>
    id: {{ id }}<br />
    <!-- Reference route parameters -->
    day: {{ $route.params.day }}<br />
    day another way: {{ dayofweek }}<br />
    month: {{ month }}
  </div>
</template>

<script>
export default {
  name: "Details",

  data() {
    return {
      id: "",
      dayofweek: "",
      month: "",
    };
  },

  // Like 'ngOnInit'. Gets called once object is created.
  created() {
    this.fetchData();
  },

  methods: {
    fetchData() {
      // Store parameters in class.
      this.id = this.$route.params.id;
      this.dayofweek = this.$route.params.day;
      this.month = this.$route.params.month;
    },
  },
};
</script>
