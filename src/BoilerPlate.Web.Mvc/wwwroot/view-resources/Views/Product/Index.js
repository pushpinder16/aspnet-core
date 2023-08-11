
(function ($) {
   
  
    var _productService = abp.services.app.product;
    l = abp.localization.getSource('BoilerPlate'),
        _$modal = $('#ProductCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ProductTable');

    var _$productTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _productService.getAll,
            inputFilter: function () {
                return $('#ProductSearchForm').serializeFormToObject();
            }
        },

        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$productTable.draw(false)
                //action: function () {
                //    _$productTable.draw(false);
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'productName',
                sortable: false
            },
            {
                targets: 2,
                data: 'description',
                sortable: false
            },

            {
                targets: 3,
                data: 'price',
                sortable: false
            },

            {
                targets: 4,
                data: 'createdDate',
                sortable: false
            },

            {
                targets: 5,
                data: 'modifiedDate',
                sortable: false
            },

            {
                targets: 6,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-Product" data-Product-id="${row.id}" data-toggle="modal" data-target="#ProductEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-Product" data-Product-id="${row.id}" data-Product-Name="${row.ProductName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var Product = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _productService
            .createp(Product)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$productTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    

    $(document).on('click', '.edit-Product', function (e) {
        var ProductId = $(this).attr('data-Product-id');

        abp.ajax({
            url: abp.appPath + 'Product/EditModal?id=' + ProductId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ProductEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

   $(document).on('click', 'a[data-target="#ProductListViewModel"]', (e) => {
        $('.nav-tabs a[href="#product-details"]').tab('show')
    });

    abp.event.on('Product.edited', (data) => {
        _$form.clearForm();
        _$productTable.ajax.reload();

    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });
    $('.btn-search').on('click', (e) => {
        searchProducts();
       /* _$productTable.ajax.reload();*/
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        _$productTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
          /*  searchProducts();*/
         /*   _$productTable.ajax.reload();*/
            return false;
        }

    });

 
    function searchProducts() {
        var keyword = $('input[name=Keyword]').val();

        $.ajax({
            url: '/Product/Filter',
            type: 'POST',
            dataType: 'json',
            data: { keyword: keyword },
            success: function (response) {
                if (response.success) {
                    _$productTable.clear().draw();
                    if (response.result && response.result.items) {
                        _$productTable.clear().draw();
                        _$productTable.rows.add(response.result.items).draw();
                        _$productTable.ajax.reload;
                      
                    }
                } else {
                    // Handle the error or display a message
                }
            },
            error: function (e) {
            }
        });
    }

    $(document).on('click', '.delete-Product', function () {
        var id = $(this).attr('data-Product-id');
        /// var ProductName = $(this).attr('data-Product-Name');

        deleteProduct(id);
    });

    function deleteProduct(id) {

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                id
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    $.ajax({
                        url: '/Product/Delete/' + id, // Replace with your actual API endpoint
                        type: 'DELETE',
                        success: function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$productTable.ajax.reload();
                        },
                        error: function () {
                            abp.notify.error(l('ErrorDeleting'));
                        }
                    });
                }
            }
        );
    }

    //function deleteProduct(id) {
    //    abp.message.confirm(
    //        abp.utils.formatString(
    //            l('AreYouSureWantToDelete'),
    //            id
    //        ),
    //        null,
    //        (isConfirmed) => {
    //            if (isConfirmed) {
    //                _productService.deleteAsync(id)
    //                    .done(() => {
    //                        abp.notify.info(l('SuccessfullyDeleted'));
    //                        _$productTable.ajax.reload();
    //                    });
    //            }
    //        }
    //    );
    //}


})(jQuery);




