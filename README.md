[Challenge][Classes][Patient/Doctor]

- Sử dụng: C# (Winform+Database)
- Viết theo mô hình 3 lớp.

- Gồm 3 classes: Faculty, Doctor, Patient
+ Faculty: chứa nhiều Doctors.
+ Doctor: chứa nhiều Patient.
+ Patient

* Trong SQL:
- Table "Faculty":
+ id_fac: primary key
+ name_fac
- Table "Doctor":
+ id_doc: primary key
+ name_doc
+ id_ fac: foreign key
- Table "Patient":
+ id_pat: primary key
+ name_pat
+ id_doc: foreign key

* Form:
- Faculty:
+ Form1: Các chức năng (show, add, update, delete, search, sort), kích vào row của khoa nào thì sẽ hiển thị Form2 chứa bác sĩ của khoa đó.
+ Form3: hiển thị thông tin chi tiết của khoa.
- Doctor:
+ Form2: Các chức năng (show, add, update, delete, search, sort), kích vào row của bác sĩ nào thì sẽ hiển thị Form5 chứa bệnh nhâ của bác sĩ đó.
+ Form4: hiển thị thông tin chi tiết của bác sĩ.
- Patient:
+ Form1: Các chức năng (show, add, update, delete, search, sort).
+ Form3: hiển thị thông tin chi tiết của bệnh nhân.
