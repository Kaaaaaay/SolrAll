<template>
  <div style="margin-top: 15px;">
    <el-row :gutter="20">
      <el-col :span="6">
        <el-autocomplete
          class="inline-input"
          v-model="state1"
          :fetch-suggestions="querySearch"
          placeholder="Please enter keywords for search"
          @select="handleSelect"
        >
          <i slot="prefix" class="el-input__icon el-icon-search"></i>
        </el-autocomplete>
      </el-col>
      <el-col :span="4">
        <el-select v-model="mode" placeholder="Mode">
          <el-option
            v-for="item in modes"
            :key="item.value"
            :label="item.label"
            :value="item.value"
          ></el-option>
        </el-select>
      </el-col>
      <el-col :span="4">
        <el-select v-model="categorie" placeholder="Categories">
          <el-option
            v-for="item in categories"
            :key="item.value"
            :label="item.label"
            :value="item.value"
          ></el-option>
        </el-select>
      </el-col>
    </el-row>
  </div>
</template>
<script>
import { search } from "@/api/searchApi";
import { edit } from "@/api/searchApi";

export default {
  data() {
    return {
      restaurants: [],
      state1: "",
      modes: [],
      categories: [],
      mode: "",
      categorie: ""
    };
  },
  methods: {
    querySearch(queryString, cb) {
      var restaurants = this.restaurants;
      var results = queryString
        ? restaurants.filter(this.createFilter(queryString))
        : restaurants;
      // 调用 callback 返回建议列表的数据
      cb(results);
    },
    createFilter(queryString) {
      return restaurant => {
        return (
          restaurant.value.toLowerCase().includes(queryString.toLowerCase()) ===
          true
        );
      };
    },
    loadPriorityAll() {
      var name = this.state1?this.state1:'*';
      this.restaurants=[];
      search(name).then(res => {
        if (res.data.length > 0) {
          for (let i = 0; i< res.data.length; i++){
            this.restaurants.push({
              value: res.data[i].name,
              key: res.data[i].id
            })
          }
        }
      })
    },
    loadModes() {
      return [
        { value: "1", label: "Mode1" },
        { value: "2", label: "Mode2" },
        { value: "3", label: "Mode3" },
        { value: "4", label: "Mode4" },
        { value: "5", label: "Mode5" }
      ];
    },
    loadCategories() {
      return [
        { value: "1", label: "Categories1" },
        { value: "2", label: "Categories2" },
        { value: "3", label: "Categories3" },
        { value: "4", label: "Categories4" },
        { value: "5", label: "Categories5" }
      ];
    },
    handleSelect() {
      var name =this.state1;
      this.restaurants.forEach(element => {
        if(element.value===name)
        edit(element.key);
      });
    }
  },
  mounted() {
    this.loadPriorityAll();
    this.modes=this.loadModes();
    this.categories=this.loadCategories();
  },
  watch: {
    state1() {
      this.loadPriorityAll();
    }
  }
};
</script>
<style>
.el-autocomplete {
  width: 100%;
}
.el-autocomplete input {
  border-top: none;
  border-right: none;
  border-left:none;
  border-radius: unset;
}
</style>
