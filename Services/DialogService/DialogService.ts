///<reference path="../../Hypermedia.ts"/>
/// <reference path="oneoptiondialogcontroller.ts" />
/// <reference path="twooptionsdialogcontroller.ts" />

module Hypermedia {
    export class DialogService {
        constructor(private $modal: ng.ui.bootstrap.IModalService) {
        }

        openOneOptionDialog = (parameter: IOneOptionDialogParameter) => {
            this.$modal.open({
                templateUrl: "/HyperMediaApi/Services/DialogService/OneOptionDialog.template.html",
                controller: "OneOptionDialogController",
                size: '',
                resolve: {
                    dialogParameter: () => parameter
                }
            });
        }

        openTwoOptionsDialog = (parameter: ITwoOptionsDialogParameter) => {
            this.$modal.open({
                templateUrl: "/HyperMediaApi/Services/DialogService/TwoOptionsDialog.template.html",
                controller: "TwoOptionsDialogController",
                size: '',
                resolve: {
                    dialogParameter: () => parameter
                }
            });
        }
    }

    angular.module("Hypermedia").service("DialogService", ["$modal", DialogService]);
}