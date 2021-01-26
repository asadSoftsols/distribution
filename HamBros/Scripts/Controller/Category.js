var d = new Date();
var datetime = d.getMonth() + '/' + d.getDate() + '/' +  d.getFullYear();

document.getElementById("alert").style.display = "none";
var Errors = ""; 
var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    debugger;
    $scope.InsertData = function () {

        var Action = document.getElementById("submtProType").getAttribute("value");
        if (Action == "Submit") {
            //Validate required fields  
                 
            var ProductTypeName = "";
            //validate Items  

            ProductTypeName = document.getElementById('ProductTypeName'); // or in jQuery use: select = this;
            if (ProductTypeName.value) {
                // value is set to a valid option, so submit form
                $('#ProductTypeName').removeClass("error");
                   
            } else {
                Errors += "Product Type is required.<br>";
                $('#ProductTypeName').addClass("error");                   
            }

            if (Errors.length > 0) {//if errors detected then notify user and cancel transaction  
                ShowMsn(Errors);
                return false; //exit function  
            } else {
                ClearMsn();
                $scope.Category = {};
                //$scope.Category.ProductTypeID = $scope.ProductTypeID;
                $scope.Category.ProductTypeName = $scope.ProductTypeName;
                $scope.Category.CreateBy = '';
                $scope.Category.CreatedAt = "";
                $scope.Category.IsActive = 1;
                $scope.Category.UpdateBy = '';
                $scope.Category.UpdateAt = "";
                $scope.Category.CompanyId = '';
                $scope.Category.BranchId = '';
                $http({
                    method: "post",
                    url: "/tbl_producttype/Insert_Category",
                    datatype: "json",
                    data: JSON.stringify($scope.Category)
                }).then(function (response) {
                    document.getElementById("alert").style.display = "block";
                    document.getElementById("outPut").innerHTML = response.data;
                    setTimeout(function () {
                        window.location.href = "index";
                    }, 5000);

                })
            }
        }
        
    }
    $scope.updateData = function () {
       
        //Validate required fields  

        var ProductTypeName = "";
        //validate Items  

        ProductTypeName = document.getElementById('ProductTypeName'); // or in jQuery use: select = this;
        if (ProductTypeName.value) {
            Errors = "";
            // value is set to a valid option, so submit form
            $('#ProductTypeName').removeClass("error");
            $('#protyp_err').val("");

        } else {
            Errors += "Product Type is required.<br>";
            $('#ProductTypeName').addClass("error");
        }

        if (Errors.length > 0) {//if errors detected then notify user and cancel transaction  
            ShowMsn(Errors);
            return false; //exit function  
        }else
        {
            $scope.Category = {};
            $scope.Category.ProductTypeName = $scope.ProductTypeName;
            $scope.Category.IsActive = 1;
            $scope.Category.UpdateBy = '';
            $scope.Category.UpdateAt = '';
            $scope.Category.UpdateTerminal = '';
            $scope.Category.CompanyId = '';
            $scope.Category.BranchId = '';
            $scope.Category.ProductTypeID = document.getElementById("ProductTypeID").value;
            $http({
                method: "post",
                url: "/tbl_producttype/Update_Category",
                datatype: "json",
                data: JSON.stringify($scope.Category)
            }).then(function (response) {
                console.log(response.data);
                document.getElementById("alert").style.display = "block";
                document.getElementById("outPut").innerHTML = response.data;
                setTimeout(function () {
                    document.getElementById("alert").style.display = "none";
                }, 5000);

            })
        }
  
}


    $scope.GetAllData = function () {
        $http({
            method: "get",            
            url: "/tbl_producttype/Get_Allproducttype"
        }).then(function (response) {
            $scope.Category = response.data;
            console.log('data', response.data);
        }, function (err) {
            document.getElementById("outPut").value = err;
        })
    };
    $scope.getDataById = function () {
        $http({
            method: "get",
            url: "/tbl_producttype/Get_producttypeById/" + id
        }).then(function (response) {
            $scope.Category = response.data;
            //console.log('data', response.data);
            $scope.ProductTypeName = response.data.ProductTypeName;
        }, function (err) {
            document.getElementById("outPut").value = err;
        })
    };  
    $scope.DeleteCat = function () {

        var Cat = $("#idForDelete").val();
        console.log('categoryid', Cat);
        

        $http({
            method: "post",
            url: "/tbl_producttype/Delete_Category/" + Cat,
            datatype: "json",
            data: Cat
        }).then(function (response) {
            
            //$("#ItemDelete").show();
            //$('#ItemDelete').delay(2000).hide(500);
            
            $("#outPut").show();
            
            setTimeout(function () {
                
                location.reload();
            }, 6000); // <-- time in milliseconds

        }, function (err) {
            $("#ItemDeleteerr").show();
        })
    };

    String.prototype.hashCode = function () {
        if (Array.prototype.reduce) {
            return this.split("").reduce(function (a, b) { a = ((a << 5) - a) + b.charCodeAt(0); return a & a }, 0);
        }
        var hash = 0;
        if (this.length === 0) return hash;
        for (var i = 0; i < this.length; i++) {
            var character = this.charCodeAt(i);
            hash = ((hash << 5) - hash) + character;
            hash = hash & hash; // Convert to 32bit integer
        }
        return hash;
    }

    $scope.UpdateEmp = function (Cat) {

        //var ProductTypeID = Cat.ProductTypeID.toString();
        //var hashedProductTypeID = ProductTypeID.hashCode();
        //document.getElementById("ProductTypeID").value = Cat.ProductTypeID;
        //$scope.ProductTypeID = Cat.ProductTypeID;
        //$scope.ProductTypeName = Cat.ProductTypeName;

        //document.getElementById("btnSave").setAttribute("value", "Update");
        //document.getElementById("btnSave").style.backgroundColor = "Yellow";
        //document.getElementById("spn").innerHTML = "Update Employee Information";
    }

    
})


function getidForDelete(id) {

    document.getElementById("idForDelete").value = id;

}

//Msn label for notifications  
function ShowMsn(message) {
    $('#protyp_err').html(message);
}

//Clear text of Msn label  
function ClearMsn() {
    $('#protyp_err').html("");
}