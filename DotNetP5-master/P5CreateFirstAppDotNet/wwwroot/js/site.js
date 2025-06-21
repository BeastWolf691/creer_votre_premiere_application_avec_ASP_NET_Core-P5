document.addEventListener('DOMContentLoaded', function () {
    const addBtn = document.getElementById('addRepairBtn');
    if (!addBtn) return;

    addBtn.addEventListener('click', () => {
        const container = document.getElementById('repair-selectors');
        const firstSelect = container.querySelector('select');
        if (!firstSelect) return;

        const newSelect = firstSelect.cloneNode(true);
        newSelect.name = "SelectedRepairIds"; // important pour ASP.NET
        newSelect.value = "";

        const wrapper = document.createElement('div');
        wrapper.className = "mb-2";
        wrapper.appendChild(newSelect);

        container.appendChild(wrapper);
    });
});
