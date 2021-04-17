<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <b>Coin Type</b> {{ currency.id }} <br />
    <b>Price USD</b> {{ currency.price_usd }} <br />
    <b>Updated at</b> {{ currency.update_time }}
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "HelloWorld",
  data() {
    return {
      msg: "Welcome to Your Vue.js App",
      currency: {
        id: "",
        price_usd: null,
        update_time: "",
      },
    };
  },
  created() {
    axios
      .get("https://api.coindesk.com/v1/bpi/currentprice.json")
      .then((resp) => {
        // Examine content that is returned by call to get data.
        let responseString = JSON.stringify(resp, null, 2);
        console.log(responseString);
        console.log(resp.data.time.updated);
        let rawPrice = resp["data"]["bpi"]["USD"]["rate_float"];
        let roundedPrice = Number(rawPrice.toFixed(2));
        this.currency.id = resp.data.chartName;
        this.currency.price_usd = roundedPrice;
        this.currency.update_time = resp.data.time.updated;
      })
      .catch((err) => {
        console.log(err);
      });
  },
};
</script>

<style scoped>
h1,
h2 {
  font-weight: normal;
}
</style>
