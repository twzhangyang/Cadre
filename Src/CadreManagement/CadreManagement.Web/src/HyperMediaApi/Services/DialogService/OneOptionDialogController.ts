///<reference path="../../Hypermedia.ts"/>

module Hypermedia {
    export interface IOneOptionDialogParameter {
        title: string;
        content: string;
        confirmButtonText: string;
        confirmEvent: () => void;
    }

    export interface IOneOptionDialogScope extends ng.IScope {
        dialogParameter: IOneOptionDialogParameter;
        ok: () => void;
    }

    export class OneOptionDialogController {
        constructor(private $scope: IOneOptionDialogScope, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private dialogParameter: IOneOptionDialogParameter) {
            this.$scope.dialogParameter = dialogParameter;

            this.$scope.ok = () => {
                if (this.$scope.dialogParameter.confirmEvent) {
                    this.$scope.dialogParameter.confirmEvent();
                }
                $modalInstance.close();
            }
        }
    }

    angular.module("Hypermedia")
        .controller("OneOptionDialogController", ["$scope", "$modalInstance", "dialogParameter", OneOptionDialogController]);
}