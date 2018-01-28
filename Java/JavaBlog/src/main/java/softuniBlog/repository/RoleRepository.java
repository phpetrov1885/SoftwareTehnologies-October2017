package softuniBlog.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import softuniBlog.entity.Role;

import javax.transaction.Transactional;


@Repository
@Transactional
public interface RoleRepository extends JpaRepository<Role, Integer> {
    Role findByName(String name);
}