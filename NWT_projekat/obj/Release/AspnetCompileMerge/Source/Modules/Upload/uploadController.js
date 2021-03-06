﻿////'use strict';

////var ap1 = angular.module('BasicHttpAuthExample')
////.controller('UploadFileController', []);
////        ap1.controller('UploadFileController',
////        ['$scope', 'upload', function ($scope, upload) {

////            $scope.$watch('files', function () {
////                $scope.upload($scope.files);
////            });
////            $scope.log = '';

////            $scope.upload = function (files) {
////                if (files && files.length) {
////                    for (var i = 0; i < files.length; i++) {
////                        var file = files[i];
////                        upload
////                            .upload({
////                                url: 'D:\\',
////                                fields: {
////                                    'username': $scope.username
////                                },
////                                file: file
////                            })
////                           .progress(function (evt) {
////                               var progresspercentage = parseint(100.0 * evt.loaded / evt.total);
////                               $scope.log = 'progress: ' + progresspercentage + '% ' +
////                                           evt.config.file.name + '\n' + $scope.log;
////                           })
////                            .success(function (data, status, headers, config) {
////                                $scope.log = 'file ' + config.file.name + 'uploaded. response: ' + json.stringify(data) + '\n' + $scope.log;
////                                $scope.$apply();
////                            });
////                    }
////                }
////            };
////        }])
////        .directive('ngThumb', ['$window', function ($window) {
////            var helper = {
////                support: !!($window.FileReader && $window.CanvasRenderingContext2D),
////                isFile: function (item) {
////                    return angular.isObject(item) && item instanceof $window.File;
////                },
////                isImage: function (file) {
////                    var type = '|' + file.type.slice(file.type.lastIndexOf('/') + 1) + '|';
////                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
////                }
////            };

////            return {
////                restrict: 'A',
////                template: '<canvas/>',
////                link: function (scope, element, attributes) {
////                    if (!helper.support) return;

////                    var params = scope.$eval(attributes.ngThumb);

////                    if (!helper.isFile(params.file)) return;
////                    if (!helper.isImage(params.file)) return;

////                    var canvas = element.find('canvas');
////                    var reader = new FileReader();

////                    reader.onload = onLoadFile;
////                    reader.readAsDataURL(params.file);

////                    function onLoadFile(event) {
////                        var img = new Image();
////                        img.onload = onLoadImage;
////                        img.src = event.target.result;
////                    }

////                    function onLoadImage() {
////                        var width = params.width || this.width / this.height * params.height;
////                        var height = params.height || this.height / this.width * params.width;
////                        canvas.attr({ width: width, height: height });
////                        canvas[0].getContext('2d').drawImage(this, 0, 0, width, height);
////                    }
////                }
////            };
////        }]);


//(function (module) {

//    var fileReader = function ($q, $log) {

//        var onLoad = function (reader, deferred, scope) {
//            return function () {
//                scope.$apply(function () {
//                    deferred.resolve(reader.result);
//                });
//            };
//        };

//        var onError = function (reader, deferred, scope) {
//            return function () {
//                scope.$apply(function () {
//                    deferred.reject(reader.result);
//                });
//            };
//        };

//        var onProgress = function (reader, scope) {
//            return function (event) {
//                scope.$broadcast("fileProgress",
//                    {
//                        total: event.total,
//                        loaded: event.loaded
//                    });
//            };
//        };

//        var getReader = function (deferred, scope) {
//            var reader = new FileReader();
//            reader.onload = onLoad(reader, deferred, scope);
//            reader.onerror = onError(reader, deferred, scope);
//            reader.onprogress = onProgress(reader, scope);
//            return reader;
//        };

//        var readAsDataURL = function (file, scope) {
//            var deferred = $q.defer();

//            var reader = getReader(deferred, scope);
//            reader.readAsDataURL(file);

//            return deferred.promise;
//        };

//        return {
//            readAsDataUrl: readAsDataURL
//        };
//    };

//    module.factory("fileReader",
//                   ["$q", "$log", fileReader]);

//}(angular.module("BasicHttpAuthExample")));

'use strict';
angular.module('BasicHttpAuthExample')
.controller('UploadController', ['$scope', '$rootScope', '$http', '$location', function ($scope, $rootScope, $http, $location) {
    
    $scope.Add = function () {
        var f = document.getElementById('file').files[0];
        var fd = new FormData();
        fd.append("file", f);
        fd.append("ID", $rootScope.globals.currentUser.ID);
        fd.append("authInfo", $rootScope.globals.currentUser.authdata);

        var ajaxRequest = $.ajax({
            type: "POST",
            url: "/api/Account/UploadFile1",
            contentType: false,
            processData: false,
            data: fd
        }).done(function (response) {
            $scope.imgUrl = 'Images/Profile/' + response.FileNames[0];
            $rootScope.globals.currentUser.imgUrl = $scope.imgUrl
            alert('Slika uspješno promjenjena!');
            $location.path('/');
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        });
    };
}]);