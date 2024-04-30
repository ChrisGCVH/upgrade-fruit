class HicomGrid {

    constructor(tableElement: string, renderElement: string) {

        // Use Grid.js to add pagination to a HTML table of data
        // @ts-ignore
        new gridjs.Grid({
            from: document.getElementById(tableElement),
            pagination: true
        }).render(document.getElementById(renderElement));
    }
}