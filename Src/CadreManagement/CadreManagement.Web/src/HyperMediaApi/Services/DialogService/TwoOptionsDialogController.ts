///<reference path="../../Hypermedia.ts"/>

module Hypermedia {
    export interface ITwoOptionsDialogParameter {
        title: string;
        content: string;
        confirmButtonText: string;
        cancelButtonText: string;
        confirmEvent: () => void;
        cancelEvent: () => void;
    }

    export interface ITwoOptionsDialogScope extends ng.IScope {
        dialogParameter: ITwoOptionsDialogParameter;
        ok: () => void;
        cancel:()=>void;
    }

    export class TwoOptionsDialogController {
        constructor(private $scope: ITwoOptionsDialogScope, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private dialogParameter: ITwoOptionsDialogParameter) {
            this.$scope.dialogParameter = dialogParameter;

            this.$scope.ok = () => {
                if (this.$scope.dialogParameter.confirmEvent) {
                    this.$scope.dialogParameter.confirmEvent();
                }
                $modalInstance.close();
            }

            this.$scope.cancel = () => {
                if (this.$scope.dialogParameter.cancelEvent) {
                    this.$scope.dialogParameter.cancelEvent();
                }
                $modalInstance.dismiss();
            }
        }
    }

    angular.module("Hypermedia")
        .controller("TwoOptionsDialogController", ["$scope", "$modalInstance", "dialogParameter", TwoOptionsDialogController]);
}