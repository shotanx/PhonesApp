#### მობილური ტელეფონების სარჩევი


პირველი გვერდი იყენებს Eager Loading-ს და DTO-ს კლასს, რათა მოხდეს მონაცემთა ბაზიდან მხოლოდ საჭირო მონაცემების მოთხოვნა.


პირველ გვერდზე შესაძლებელია მწარმოებლის, დასახელების, ფასების მიხედვით მობილურების ძიება. ასევე შესაძლებელია ფასისა და დასახელების მიხედვით სორტირება.


ფილტრაციისას და სორტირებისას პარამეტრები არ იკარგება. ანუ შესაძლებელია გავფილტროთ რამდენიმე პარამეტრით და ამავდროულად მოვახდინოთ სორტირება.


HomeController-ის Index Action-ის მთლიანი ლოგიკა გატანილია PhoneBusinessLogic კლასის GetProductsAsync(PhoneSearchModel searchModel) ასინქრონულ მეთოდში.
ეს მეთოდი იყენებს PaginatedList კლასის Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, PhoneSearchModel searchModel) ასინქრონულ მეთოდს, რითიც ახდენს სიის გვერდებად გადანაწილებას.


Index Action მეთოდის პარამეტრები გატანილია ცალკე PhoneSearchModel კლასში.


პროგრამა იყენებს MSSQLLocalDB-ს. პირველი გაშვებისას DbInitializer კლასის Initialize(PhonesContext context) მეთოდი ავტომატურად ახდენს მონაცემთა ბაზის შექმნას და მის პოპულაციას.