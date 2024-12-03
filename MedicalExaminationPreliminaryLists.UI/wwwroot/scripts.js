$(document).ready(function () {
    $(document).on("click", ".fold-table tr.view", function () {
        var $this = $(this);
        var $foldRow = $this.next(".fold");

        $this.toggleClass("open");
        $foldRow.toggleClass("open");
    });
});