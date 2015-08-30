module M {
    "use strict";

    export class activePanel {
        // properties
        public dashboard: boolean;
        public wol: boolean;

        // constructor
        constructor() {
            this.dashboard = false;
            this.wol = false;
        }
    }
}