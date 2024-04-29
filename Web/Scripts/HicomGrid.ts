class HicomGrid {

    constructor(tableElement: string, renderElement: string) {
        // @ts-ignore
        new gridjs.Grid({
            from: document.getElementById(tableElement),
            pagination: true
        }).render(document.getElementById(renderElement));
    }
}