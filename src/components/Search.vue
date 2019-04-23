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
                @select="handleEnter"
                @keyup.enter.native="handleEnter"
                clearable
              >
                <i slot="prefix" class="el-input__icon el-icon-search"></i>
              </el-autocomplete>
            </el-col>
            <el-col :span="4">
              <el-select v-model="mode" placeholder="Mode" clearable @change="handleModeChange">
                <el-option
                  v-for="item in modes"
                  :key="item.label"
                  :label="item.label"
                  :value="item.label"
                ></el-option>
              </el-select>
            </el-col>
            <el-col :span="4">
              <el-select
                v-model="categorie"
                placeholder="Categories"
                clearable
                @change="handleCateChange"
              >
                <el-option
                  v-for="item in categories"
                  :key="item.label"
                  :label="item.label"
                  :value="item.label"
                ></el-option>
              </el-select>
            </el-col>
          </el-row>
        </div>

        <el-table :data="sppData" stripe style="width: 100%">
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
                <span style="color:#000">{{scope.row.name}}</span>
              </el-row>
              <el-row>
                <span>{{scope.row.categorie}}</span>
              </el-row>
              <el-row>
                <span>{{scope.row.class}}</span>
              </el-row>
            </template>
          </el-table-column>
          <el-table-column width="180">
            <template slot-scope="scope">
              <el-row>
                <span>{{scope.row.vender}}</span>
              </el-row>
            </template>
          </el-table-column>
          <el-table-column width="180">
            <template slot-scope="scope">
              <el-row>
                <span>{{scope.row.pn}}</span>
              </el-row>
            </template>
          </el-table-column>
          <el-table-column width="180">
            <template>
              <el-row>
                <a href>Approve</a>
              </el-row>
              <el-row>
                <a href>Reject</a>
              </el-row>
            </template>
          </el-table-column>
        </el-table>
      </el-main>
    </el-container>
  </el-container>
</template>
<script>
import C209_coupe_C from "../assets/C209_coupe_C.jpg";
import C213_saloon_E from "../assets/C213_saloon_E.jpg";
import C215_coupe_CL from "../assets/C215_coupe_CL.jpg";
import C257_sedan_C from "../assets/C257_sedan_C.jpg";
import Citan_MPV_C from "../assets/Citan_MPV_C.jpg";
import G63 from "../assets/G63 AMG_SUT_G.jpg";
import MB100_Van_M from "../assets/MB100_Van_M.jpg";
import GT_coupe_GT from "../assets/Mercedes-AMG GT_coupe_GT.jpg";
import Vito_Van_V from "../assets/Vito_Van_V.jpg";
import W177_hatchback_A from "../assets/W177_hatchback_A.jpg";
import W212_Saloon_E from "../assets/W212_Saloon_E.jpg";
import W213_coupe_E from "../assets/W213_coupe_E.jpg";
import W218_sedan_C from "../assets/W218_sedan_C.jpg";
import W221_sedan_C from "../assets/W221_sedan_C.jpg";
import W222_sedan_S from "../assets/W222_sedan_S.jpg";
import X164_SUV_GL from "../assets/X164_SUV_GL.jpg";
import { search } from "@/api/searchApi";
import { edit } from "@/api/searchApi";

export default {
  data() {
    return {
      sppData: [],
      tableData: [
        {
          srcdata: C209_coupe_C,
          name: "C209",
          class: "C-Class",
          categories: "Coupe",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: C213_saloon_E,
          name: "C213",
          class: "E-Class",
          categories: "Saloon",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: C215_coupe_CL,
          name: "C215",
          class: "CL-Class",
          categories: "Coupe",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: C257_sedan_C,
          name: "C257",
          class: "C-Class",
          categories: "Sedan",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: Citan_MPV_C,
          name: "Citan",
          class: "C-Class",
          categories: "MPV",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: G63,
          name: "G63",
          class: "G-Class",
          categories: "AMG",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: MB100_Van_M,
          name: "MB100",
          class: "M-Class",
          categories: "Van",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: GT_coupe_GT,
          name: "GT",
          class: "GT-Class",
          categories: "Coupe",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: Vito_Van_V,
          name: "Vito",
          class: "V-Class",
          categories: "Van",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: W177_hatchback_A,
          name: "W177",
          class: "A-Class",
          categories: "Hatchback",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: W212_Saloon_E,
          name: "W212",
          class: "E-Class",
          categories: "Saloon",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: W213_coupe_E,
          name: "W213",
          class: "E-Class",
          categories: "Coupe",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: W218_sedan_C,
          name: "W218",
          class: "C-Class",
          categories: "Sedan",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: W221_sedan_C,
          name: "W221",
          class: "C-Class",
          categories: "Sedan",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: W222_sedan_S,
          name: "W222",
          class: "S-Class",
          categories: "Sedan",
          vender: "Jack",
          pn: "Adison"
        },
        {
          srcdata: X164_SUV_GL,
          name: "X164",
          class: "GL-Class",
          categories: "SUV",
          vender: "Jack",
          pn: "Adison"
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
    handleModeChange() {
      if (this.mode) {
        this.sppData = [];
        this.tableData.forEach(car => {
          if (this.mode === car.class) {
            this.sppData.push(car);
          }
        });
      } else {
        this.sppData = this.tableData;
      }
    },
    handleCateChange() {
      if (this.categorie) {
        this.sppData = [];
        this.tableData.forEach(car => {
          if (this.categorie === car.categories) {
            this.sppData.push(car);
          }
        });
      } else {
        this.sppData = this.tableData;
      }
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
        { value: "1", label: "A-Class" },
        { value: "2", label: "C-Class" },
        { value: "3", label: "E-Class" },
        { value: "4", label: "GL-Class" },
        { value: "5", label: "S-Class" },
        { value: "6", label: "M-Class" },
        { value: "7", label: "G-Class" }
      ];
    },
    loadCategories() {
      return [
        { value: "1", label: "Coupe" },
        { value: "2", label: "Saloon" },
        { value: "3", label: "MPV" },
        { value: "4", label: "Sedan" },
        { value: "5", label: "AMG" },
        { value: "6", label: "Van" },
        { value: "7", label: "SUV" },
        { value: "8", label: "Hatchback" }
      ];
    },
    handleEnter() {
      var name = this.state1;
      this.restaurants.forEach(element => {
        if (element.value === name) edit(element.key);
      });
      this.sppData = [];
      this.tableData.forEach(car => {
        if (this.state1 === car.name) {
          this.sppData.push(car);
        }
      });
    }
  },
  mounted() {
    this.loadPriorityAll();
    this.sppData = this.tableData;
    this.modes = this.loadModes();
    this.categories = this.loadCategories();
  },
  watch: {
    state1(newVal) {
      if (!newVal) {
        this.sppData = this.tableData;
      }
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


 