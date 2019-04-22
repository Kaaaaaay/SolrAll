<template>
  <el-container>
    <el-aside width="200px" class="spanColor">
      <el-row>
        <el-col :span="18" class="leftBar">
          <img src="../assets/logo1.png" style="vertical-align:middle">
          <label style="margin-left:10px;color:rgb(194, 194, 194)">SSP Platform</label>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="14" style="margin-left: 40%; margin-top: 20px;">
          <img src="../assets/userLogo.png">
        </el-col>
      </el-row>
      <el-row style="width:100%;color:#fff;text-align:center;font-size:11px">
        <label style="margin-left:10%;color:rgb(194, 194, 194)">Peter - PM</label>
      </el-row>
      <el-row style="margin-top:15%">
        <el-menu
          default-active="1"
          background-color="rgb(34, 34, 34)"
          text-color="rgb(194, 194, 194)"
          active-text-color="rgb(27, 94, 193)"
          style="border:0"
          class="el-menu-vertical-demo menu-text-align"
        >
          <el-menu-item index="1">
            <span slot="title">New Car Creation</span>
          </el-menu-item>
          <el-menu-item index="2">
            <span slot="title">New Car Release</span>
          </el-menu-item>
          <el-menu-item index="3">
            <span slot="title">Cross Carline Topic Release</span>
          </el-menu-item>
        </el-menu>
      </el-row>
    </el-aside>
    <el-container>
      <el-header style="padding:0;color:rgb(200, 200, 200);height:100px">
        <el-row
          style="text-align: right;height:40px;border-bottom-style:solid;border-bottom-width:1px;"
        >
          <img
            src="../assets/ring.png"
            style="margin-top:10px;vertical-align:middle;margin-right:10px"
          >
          <img
            src="../assets/exit.png"
            style="margin-top:10px;vertical-align:middle;margin-right:10px"
          >
        </el-row>
        <el-row>
          <el-col>&nbsp;</el-col>
        </el-row>
        <el-row style="height:40px;">
          <el-col :span="12">
            <label style="margin:20px;font-size:20px;font-weight:600;color:#000">New Car Release</label>
          </el-col>
          <el-col :span="12" style="text-align:right;">
            <el-button type="primary" style="margin-right:30px">Create</el-button>
          </el-col>
        </el-row>
      </el-header>
      <el-main class="el-main elborder-color-size">
        <div style="margin-top: 5px;">
          <el-row :gutter="20">
            <el-col :span="7">
              <el-autocomplete
                class="inline-input"
                v-model="state1"
                :fetch-suggestions="querySearch"
                placeholder="Please enter keywords for search"
                @keyup.enter.native="handleEnter"
                clearable
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

        <el-table :data="sppData"
        stripe style="width: 100%">
          <el-table-column width="180">
            <template slot-scope="scope">
              <img
                :src="scope.row.srcdata"
                style="margin-top:10px;vertical-align:middle;margin-right:10px"
              >
            </template>
          </el-table-column>
          <el-table-column width="360">
            <template slot-scope="scope">
            <el-row>
              <span style="color:#000">
                {{scope.row.name}}
              </span>
            </el-row>
            <el-row>
              <span>
                SUV
              </span>
            </el-row>
            <el-row>
              <span>
                G-class
              </span>
            </el-row>
            </template>
          </el-table-column>
          <el-table-column width="180">
            <template>
            <el-row>
              <span>
                Vendor Name
              </span>
            </el-row>
            </template>
          </el-table-column>
          <el-table-column width="180">
            <template>
            <el-row>
              <span>
                PN Name
              </span>
            </el-row>
            </template>
          </el-table-column>
          <el-table-column width="180">
            <template>
            <el-row>
              <a href="">
                Approve
              </a>
            </el-row>
            <el-row>
              <a href="">
                Reject
              </a>
            </el-row>
            </template>
          </el-table-column>
        </el-table>
      </el-main>
    </el-container>
  </el-container>
</template>
<script>
import image1 from "../assets/bigblack.png";
import image2 from "../assets/bigbrown.png";
import image3 from "../assets/middlewhite.png";
import image4 from "../assets/redsmall.png";
import { search } from "@/api/searchApi";
import { edit } from "@/api/searchApi";

export default {
  data() {
    return {
      sppData:[],
      tableData: [
        {
          srcdata: image1,
          name: "New G-Class Off-road Vehicle",
          address: "上海市普陀区金沙江路 1518 弄"
        },
        {
          srcdata: image2,
          name: "New G-Class Off-road Vehicle",
          address: "上海市普陀区金沙江路 1517 弄"
        },
        {
          srcdata: image3,
          name: "The new A-Class",
          address: "上海市普陀区金沙江路 1519 弄"
        },
        {
          srcdata: image4,
          name: "New G-Class",
          address: "上海市普陀区金沙江路 1516 弄"
        }
      ],
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
      var name = this.state1 ? this.state1 : "*";
      this.restaurants = [];
      search(name).then(res => {
        if (res.data.length > 0) {
          for (let i = 0; i < res.data.length; i++) {
            this.restaurants.push({
              value: res.data[i].name,
              key: res.data[i].id
            });
          }
        }
      });
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
    handleEnter() {
      var name = this.state1;
      this.restaurants.forEach(element => {
        if (element.value === name) edit(element.key);
      });
      var mainSkuRandom = Math.round(Math.random(3))
      this.sppData=[];
      this.sppData.push(this.tableData[mainSkuRandom])
    }
  },
  mounted() {
    this.loadPriorityAll();
    this.sppData=this.tableData;
    this.modes = this.loadModes();
    this.categories = this.loadCategories();
  },
  watch: {
    state1() {
      this.loadPriorityAll();
    }
  }
};
</script>
<style>
.menu-text-align {
  border: 0;
  text-align: center;
}
.leftBar {
  color: antiquewhite;
  margin-left: 20%;
  margin-top: 20px;
}
.elborder-color-size {
  border-color: #eee;
  border-top-width: 20px;
  border-bottom-width: 20px;
  border-left-width: 40px;
  border-right-width: 40px;
  border-style: solid;
}
.left {
  height: 100%;
  margin: 0;
  padding: 0;
  border: 0;
}

body {
  margin: 0;
  padding: 0;
  height: 100%;
}

.spanColor {
  height: 100%;
  background-color: rgb(34, 34, 34);
}
.el-autocomplete {
  width: 100%;
}
.el-autocomplete input {
  border-top: none;
  border-right: none;
  border-left: none;
  border-radius: unset;
}
html {
  height: 100%;
}
.el-container {
  width: 100%;
  height: 100%;
}
</style>
