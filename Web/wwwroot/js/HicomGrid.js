class HicomGrid {
    constructor(tableElement, renderElement) {
        new gridjs.Grid({
            from: document.getElementById(tableElement),
            pagination: true
        }).render(document.getElementById(renderElement));
    }
}
