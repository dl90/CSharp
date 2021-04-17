export default {
  // This is called once the object is built.
  created: function () {
    console.log("mymixin has been created.")
    this.showMixinAlert();
  },
  methods: {
    showMixinAlert: function () {
      console.log("Hi this is from mymixin!");
    },
    setFullName: function (name) {
      this.fullname = name
    },
    getShoe (id) {
      for (var i = 0; i < this.footwear.length; i++) {
        if (id == this.footwear[i].id) {
          this.footwearItem = this.footwear[i];
          alert(this.footwearItem.shoe);
        }
      }
    }
  },
  data () {
    return {
      mixinMsg: 'Hello from mixin',
      fullname: null,
      footwearItem: null,
      footwear:
        [{
          id: 100,
          shoe: 'Analeigh Suede Peeptoe Shooties ',
          brand: 'Ann Taylor'
        },

        {
          id: 200,
          shoe: 'Karen Millen Mesh and Leather Pumps ',
          brand: 'Karen Millen'
        },

        {
          id: 300,
          shoe: 'Olivia Suede Boots',
          brand: 'Joie'
        }]
    }
  }
}
