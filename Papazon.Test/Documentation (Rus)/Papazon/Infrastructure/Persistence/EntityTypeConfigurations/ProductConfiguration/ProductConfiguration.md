ProductConfiguration - �����, �������������� ����� ������������ Product ����� Fluent API.

ProductConfiguration ��������� ��������� IEntityTypeConfiguration<Product> �� ������������ ����
Microsoft.EntityFrameworkCore, ����������� ���������� ������������ �������� Product � ��������� �����, 
� �� � ����� OnModelCreated �� DBContext, ������� ������� ����.

IEntityTypeConfiguration<T> �������� ���� ����� Configer, ����������� ����������� ������������ ��������. ������ �� ����������, ��
��� ���� ��������� EntityTypeBilder<T> �� ������������ ���� Microsoft.Microsoft.EntityFrameworkCore.Metadata.Builders.Builders.
������ ����� ���������� EntityTypeBilder<T> �������� �������� ������������ ��������� ����� ��� ������. 


��� ��������� �� ���:   //  (p => p.Property) = (Expression<Func<TEntity,Object>>)
    .HasKey(p => p.Property)            -   ������ ���� � ����������� ��������� ������
    .HasIndex(p => p.Property)          -   ������ ������
    .HasIndex(..).IsUnique()            -   ������ ����������� ����: ������ ���������� ��������
    .HasProperty(p => p.Property)       -   ������ ����
    .HasProperty(..).HasMaxLenght(int)  -   ������ ����������� ����: ������������ ������ �� ���� ���� (��� string - varchar)
